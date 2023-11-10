using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 倒计时的类
/// </summary>
public class CountDown
{
    public int hour;
    public int minute;
    public int second;

    private int countDownTime;
    public int CountDownTime { get { return countDownTime; } }
    private int totalTime;
    public int TotalTime { get { return totalTime; } }

    public CountDown(int _hour,int _minute,int _second)
    {
        
        hour = _hour;
        minute = _minute;
        second = _second;
        totalTime = 3600 * hour + 60 * minute + second;
        countDownTime = totalTime;
    }

    private float time = 0;

    /// <summary>
    /// </summary>
    public void UpdateTime()
    {
        time += Time.deltaTime;
        if (time>=1&& countDownTime != 0)
        {
            countDownTime--;
            time = 0;
        }
    }
}
//
public class CountDownSlider : MonoBehaviour
{
    public Text countDownText;
    public Slider countDownSlider;
    private Image sliderImg;
    public Button startCountDownBtn;
    private CountDown countDown = null;

    public GameManagerScript gameManagerScript;
    private bool isOver;

    public static bool isAbleToCount;

    public CatMoving cat;

    void Start()
    {
        countDownSlider.value = 1;
        sliderImg = countDownSlider.transform.Find("Fill Area/Fill").GetComponent<Image>();
        startCountDownBtn.onClick.AddListener(OnCountDownClick);
        isOver = false;
        isAbleToCount = true;
    }

    private void OnCountDownClick()
    {
        if(isAbleToCount == true){
            countDown = new CountDown(0, 0, 10);
            isAbleToCount = false;//开始倒计时构造一个一分钟的倒计时对象
        }
        
  
    }

    void Update()
    {
        if (countDown!=null)
        {
            
            countDown.UpdateTime();//开启倒计时
            countDownText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", countDown.CountDownTime / 3600,
                countDown.CountDownTime / 60, countDown.CountDownTime % 60);//格式化输出倒计时时间
            countDownSlider.value = countDown.CountDownTime / (countDown.TotalTime * 1.0f);//将倒计时时间映射到进度条上
            //控制进度条和文本的显示颜色
            Color newColor = new Vector4(0.70f, 0.44f, 0.56f, 0.7f);
                
                sliderImg.color = newColor;
                countDownText.color = Color.white;
                if(DestinationTest.isFinished == true){

                }
                else if (countDownSlider.value==0)
                {
                    if(cat.isFinished == false && isOver == false ){
                        gameManagerScript.GameOver();
                        isOver = true;
                    }
                    countDown = null;//倒计时结束
                    
                }
        }
    }
}

