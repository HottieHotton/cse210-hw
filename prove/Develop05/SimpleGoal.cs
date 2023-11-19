public class SimpleGoal : Goal{

    public List<string> _simpleList;

    public SimpleGoal() : base("Simple Goal", 5){
        _simpleList = new List<string>();
        _simpleList.Add("Go for a walk");
        _simpleList.Add("100");
        _simpleList.Add("Send a scripture to a friend");
        _simpleList.Add("50");
        _simpleList.Add("Pray for someone");
        _simpleList.Add("25");
    }

    public override void AddGoal(){
        string goal;
        string points;

        Console.WriteLine("Please enter your Goal: ");
        goal = Console.ReadLine();
        _simpleList.Add(goal);

        Console.WriteLine("Please enter the points for this goal: ");
        points = Console.ReadLine();
        _simpleList.Add(points);
    }

    public override int RecordEvent(){
        int count = 0;
        int list = 0;
        int user;
        string goal;

        Console.Clear();
        foreach (Object i in _simpleList){
            if(count%2 == 0){
                Console.WriteLine($"{list+=1}: {i}");
            }else{
                Console.WriteLine($"Points: {i}");
            }
            count++;
        }

        Console.WriteLine("\nPlease select the goal to complete: ");
        user = int.Parse(Console.ReadLine());
        goal = _simpleList[user];
        _score = int.Parse(_simpleList[user+1]);
        _simpleList[user] = $"[X] {goal}";
        
        return _score;
    }

    public override void DisplayGoals(){
        int count = 0;
        foreach (Object i in _simpleList){
            if(count%2 == 0){
                Console.WriteLine($"Goal: {i}");
            }else{
                Console.WriteLine($"Points: {i}");
            }
            count++;
        }
    }
}