﻿public class Segment 
{
    public Point p1;
    public Point p2;

    public Segment(double x1, double y1, double x2, double y2)
    {
        this.p1 = new Point(x1, y1);
        this.p2 = new Point(x2, y2);
    }

    public Segment() { }
}
