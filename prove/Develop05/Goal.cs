public abstract class Goal{
    protected string _description;
    protected int _score;

    public Goal(string description, int points){
        this._description = description;
        this._score = points;
    }

    public virtual void AddGoal(){}

    public virtual int RecordEvent(){ return _score;}

    public virtual void DisplayGoals(){}
}