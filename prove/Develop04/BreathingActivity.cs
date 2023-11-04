public class BreathingActivity : Activity {
    public BreathingActivity() : base("\nBreathing Activty", "This activity will help you relax by guiding you through breathing exercises.\n")
    {

    }
    public void Start()
    {
        base.StartMessage();
    }

    public void RunActivity(int time){
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(time);
        DateTime currentTime = DateTime.Now;

        
        while(currentTime < futureTime)
        {
            Console.WriteLine("Breath In...");
            base.PauseAnimation(3);
            Console.WriteLine("Breath Out...");
            base.PauseAnimation(3);
            currentTime = DateTime.Now;
        }
        Console.WriteLine($"Run for {time} seconds!");
        Thread.Sleep(3000);
    }
}