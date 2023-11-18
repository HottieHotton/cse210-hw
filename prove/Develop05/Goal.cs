public abstract class Goal{
    protected string _name;
    protected string _description;
    protected int _score;

    private List<Goal> goals = new List<Goal>();

    public Goal(string name, string description){
        this._name = name;
        this._description = description;
    }

    public void ShowScore(){

    }
}