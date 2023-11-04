public class BreathingActivity : Activity {
    public BreathingActivity() : base("\nBreathing Activty", "This activity will help you relax by guiding you through breathing exercises.\n")
    {

    }
    public void Start()
    {
        base.StartMessage();
    }

    public void RunActivity(int time){
        Console.Clear();
        base.Countdown();
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(time);
        DateTime currentTime = DateTime.Now;

        while(currentTime < futureTime)
        {
            Console.WriteLine("Breath In...");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.WriteLine("Breath Out...");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            currentTime = DateTime.Now;
        }
        base.EndMessage($"Finished! You completed this task in {time} seconds!");
        Thread.Sleep(3000);
        Console.Clear();
    }
}