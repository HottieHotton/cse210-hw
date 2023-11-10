public class Rectangle : Shape{
    private double _l;
    private double _w;

    public Rectangle(string color, double l, double w) : base (color)
    {
        _l = l;
        _w = w;
    }

    public override double GetArea(){return _l*_w;}
}