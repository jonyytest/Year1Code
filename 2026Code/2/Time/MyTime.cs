class MyTime
{
    private int hour;
    private int minute;
    private int second;
    public MyTime()
    {
    }
    public MyTime(int hour, int minute, int second)
    {
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public void SetTime(int hour, int minute, int second)
    {
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }
    public void SetHour(int hour)
    {
        this.hour = hour;
    }
    public void SetMinute(int minute)
    {        
        this.minute = minute;
    }
    public void SetSecond(int second)
    {
        this.second = second;
    }
    public int GetHour()    
    {
        return hour;    
    }
    public int GetMinute()
    {
        return minute;
    }
    public int GetSecond()   
    {
        return second;
    }
    public override String ToString()
    {
        return $"{hour:D2}:{minute:D2}:{second:D2}";
    }
    public MyTime NextSecond()
    {
        this.second++;
        if (this.second == 60)
        {            
            this.second = 0;
            this.minute++;
        }
        return this;
    }
    public MyTime NextMinute()
    {
        this.minute++;
        if (this.minute == 60)
        {
            this.minute = 0;
            this.hour++;
        }
        return this;
    }
    public MyTime NextHour()
    {
        this.hour++;
        if (this.hour == 24)
        {
            this.hour = 0;
        }
        return this;
    }
    public MyTime PreviousSecond()
    {
        this.second--;
        if (this.second < 0)
        {
            this.second = 59;
            this.minute--;
        }
        return this;
    }
    public MyTime PreviousMinute()
    {
        this.minute--;
        if (this.minute < 0)
        {
            this.minute = 59;
            this.hour--;
        }
        return this;
    }
    public MyTime PreviousHour()
    {
        this.hour--;
        if (this.hour < 0)
        {
            this.hour = 23;
        }
        return this;
    }


}