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
            BreathingActivity _breathing = new BreathingActivity();
            _breathing.RunActivity(_duration);
        }
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
}