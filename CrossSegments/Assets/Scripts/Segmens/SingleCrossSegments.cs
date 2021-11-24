public class SingleCrossSegments
{
    private static double a, b, c;

    public static double A { get => a; set => a = value; }                                                    // Коэффициенты линейного уравнения прямой
    public static double B { get => b; set => b = value; }
    public static double C { get => c; set => c = value; }

    public static Point CrossingPoint(double a1, double b1, double c1, double a2, double b2, double c2)       // нахождение точки пересечения
    {
        Point pt = new Point();
        double d = (double)(a1 * b2 - b1 * a2);                                                              // решение системы лин. уравнени методом Крамера
        double dx = (double)(-c1 * b2 + b1 * c2);
        double dy = (double)(-a1 * c2 + c1 * a2);
        pt.X = (double)(dx / d);
        pt.Y = (double)(dy / d);
        return pt;
    }

    protected static double VectorMultiplication(double ax, double ay, double bx, double by)                 // векторное произведение
    {
        return ax * by - bx * ay;
    }

    public static bool CheckCrossing(Segment seg1, Segment seg2)                                             // проверка пересечения
    {
        double v1 = VectorMultiplication(seg2.p2.X - seg2.p1.X, seg2.p2.Y - seg2.p1.Y, seg1.p1.X - seg2.p1.X, seg1.p1.Y - seg2.p1.Y);
        double v2 = VectorMultiplication(seg2.p2.X - seg2.p1.X, seg2.p2.Y - seg2.p1.Y, seg1.p2.X - seg2.p1.X, seg1.p2.Y - seg2.p1.Y);
        double v3 = VectorMultiplication(seg1.p2.X - seg1.p1.X, seg1.p2.Y - seg1.p1.Y, seg2.p1.X - seg1.p1.X, seg2.p1.Y - seg1.p1.Y);
        double v4 = VectorMultiplication(seg1.p2.X - seg1.p1.X, seg1.p2.Y - seg1.p1.Y, seg2.p2.X - seg1.p1.X, seg2.p2.Y - seg1.p1.Y);

        if ((v1 * v2) < 0 && (v3 * v4) < 0)                                                         // условие пересечения использует свойства векторного произведения
            return true;
        return false;
    }
        
    public static void LineEquation(Segment seg)                                                                // построение уравнения прямой
    {
         A = seg.p2.Y - seg.p1.Y;
         B = seg.p1.X - seg.p2.X;
         C = -seg.p1.X * (seg.p2.Y - seg.p1.Y) + seg.p1.Y * (seg.p2.X - seg.p1.X);
    }
}
