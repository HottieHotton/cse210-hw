public class Circle : Shape {
    private double _r;
    private double _pi = Math.PI;

    public Circle(string color, double r) : base (color)
    {
        _r = r;
    }

    public override double GetArea(){return _r*_r*_pi;}
}