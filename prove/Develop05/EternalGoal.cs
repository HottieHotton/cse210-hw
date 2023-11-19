public class EternalGoal: Goal{

    public List<string> _eternalList;

    public EternalGoal() : base("Eternal Goals", 5){
        _eternalList = new List<string>();
        _eternalList.Add("Clean your room");
        _eternalList.Add("100");
        _eternalList.Add("Read your scriptures");
        _eternalList.Add("50");
        _eternalList.Add("Do a workout");
        _eternalList.Add("25");
    }

    public override void AddGoal(){
        string goal;
        string points;

        Console.WriteLine("Please enter your Goal: ");
        goal = Console.ReadLine();
        _eternalList.Add(goal);

        Console.WriteLine("Please enter the points for this goal: ");
        points = Console.ReadLine();
        _eternalList.Add(points);
    }

    public override int RecordEvent(){
        int count = 0;
        int list = 0;
        int user;
        string goal;

        Console.Clear();
        foreach (Object i in _eternalList){
            if(count%2 == 0){
                Console.WriteLine($"{list+=1}: {i}");
            }else{
                Console.WriteLine($"Points: {i}");
            }
            count++;
        }

        Console.WriteLine("\nPlease select the goal to complete: ");
        user = int.Parse(Console.ReadLine());
        goal = _eternalList[user];
        _score = int.Parse(_eternalList[user+1]);
        
        return _score;
    }

    public override void DisplayGoals(){
        int count = 0;
        foreach (Object i in _eternalList){
            if(count%2 == 0){
                Console.WriteLine($"Goal: {i}");
            }else{
                Console.WriteLine($"Points: {i}");
            }
            count++;
        }
    }
}