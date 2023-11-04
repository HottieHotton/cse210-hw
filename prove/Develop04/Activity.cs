public abstract class Activity{
    protected int _duration;
    protected string _description;
    protected string _name;

    public Activity(string name, string description){
        this._name = name;
        this._description = description;
    }

    public void StartMessage(){
        Console.WriteLine(_name);
        Console.WriteLine(_description);
        Console.WriteLine("Please enter the time in seconds you want to do this activity: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("You will do this activity for "+_duration+" seconds! Good luck!\n");

        if(GetType().Name == "BreathingActivity"){
            BreathingActivity breathing = new BreathingActivity();
            breathing.RunActivity(_duration);
        }
        else if(GetType().Name == "ReflectionActivity"){
            ReflectionActivity reflecting = new ReflectionActivity();
            reflecting.RunActivity(_duration);
        }
        else if(GetType().Name == "ListingActivity"){
            ListingActivity listing = new ListingActivity();
            listing.RunActivity(_duration);
        }
    }

    public void Countdown(){
        Console.WriteLine("This program will begin in..");
        Console.Write("5");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("4");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("3");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("2");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("1");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("Begin!");
    }

    public void PauseAnimation(int timer){
        int x = 0;
        while(x != timer){
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            x++;
        }
    }

    public void EndMessage(string end){
        Console.WriteLine(end);
    }
}