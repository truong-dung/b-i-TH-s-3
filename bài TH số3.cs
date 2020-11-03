using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;

namespace BTH_3___4
{
    // bai 1- BTH3
    class PhanSo
    {
        private int ts, ms;
        public PhanSo()
        {
            ts = 0; ms = 1;
        }
        public PhanSo(int ts, int ms)
        {
            this.ts = ts;
            this.ms = ms;

        }
        public void Nhap()
        {
            Console.Write("Nhap tu so:");
            ts = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so:");
            ms = int.Parse(Console.ReadLine());
        }
        public void Hien()
        {
            if (ms == 1)
                Console.WriteLine("{0}", ts);
            else
                Console.WriteLine("{0}/{1}", ts, ms);
        }
        public int USCLN(int x, int y)
        {
            x = Math.Abs(x);
            y = Math.Abs(y);
            while (x != y)
            {
                if (x > y) x = x - y;
                if (y > x) y = y - x;
            }
            return x;
        }
        public PhanSo Rutgon()
        {
            int uc = USCLN(this.ts, this.ms);
            this.ts = this.ts / uc;
            this.ms = this.ms / uc;
            return this;
        }
        public PhanSo Tong(PhanSo t2)
        {
            PhanSo t = new PhanSo();
            t.ts = this.ts * t2.ms + this.ms * t2.ts;
            t.ms = this.ms * t2.ms;
            return t.Rutgon();
        }
        public PhanSo Hieu(PhanSo t2)
        {
            PhanSo t = new PhanSo();
            t.ts = this.ts * t2.ms - t2.ts * this.ms;
            t.ms = this.ms * t2.ms;
            return t;
        }

        public static bool operator ==(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms == t2.ts * t1.ms;
        }
        public static bool operator !=(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms != t2.ts * t1.ms;
        }

        public static bool operator >(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms > t2.ts * t1.ms;
        }
        public static bool operator <(PhanSo t1, PhanSo t2)
        {
            return t1.ts * t2.ms < t2.ts * t1.ms;
        }
    }
    class APP
    {
        static void Main2()
        {
            PhanSo t1 = new PhanSo(6, 8);
            PhanSo t2 = new PhanSo(7, 10);
            Console.Write(" Tong 2 phan so la: ");
            PhanSo t = t1.Tong(t2);
            t.Hien();
            Console.Write(" Hieu 2 phan so la: ");
            PhanSo t3 = t1.Hieu(t2);
            t3.Hien();
        }
    }
}
// bai 3 - BTH 3
class Time
{
    private int gio;
    private int phut;
    private int giay;
    public Time()
    {
        this.gio = 0;
        this.phut = 0;
        this.giay = 0;
    }
    public Time(int gio, int phut, int giay)
    {
        this.gio = gio;
        this.phut = phut;
        this.giay = giay;
    }
    public int Gio
    {
        get
        { return gio; }
        set
        { gio = value; }
    }
    public int Phut
    {
        get
        { return phut; }
        set
        { phut = value; }
    }
    public int Giay
    {
        get
        { return giay; }
        set
        { giay = value; }
    }
    public void normlize(int gio, int phut, int giay)
    {
        phut += giay % 60;
        giay = giay % 24;
        gio += phut / 60;
    }
    public Time advance(int gio, int phut, int giay)
    {
        Time t = new Time();
        t.gio = this.gio + gio;
        t.phut = this.phut + phut;
        t.giay = this.giay + giay;
        t.giay = t.giay % 60;
        t.phut = t.giay / 60;
        t.gio = t.phut / 60;
        t.phut = t.phut % 60;
        t.gio = t.gio % 24;
        return t;
    }
    public void Hien()
    {
        Console.WriteLine("Thoi gian hien hanh:{0}:{1}:{2},gio, phut, giay");
    }
}

//bai 4-BTH 3
class HocSinh
{
    private string s;
    private double dt, dl, dh;
    public void nhap()
    {
        Console.Write("Nhap ho ten:");
        s = Console.ReadLine();
        Console.Write("nhap diem toan:");
        dt = double.Parse(Console.ReadLine());
        Console.Write("Nhap diem Ly");
        dl = double.Parse(Console.ReadLine());
        Console.Write("Nhap diem Hoa:");
        dh = double.Parse(Console.ReadLine());
    }
    public void Hien()
    {
        Console.Write("Thong tin can hien thi:");
        Console.WriteLine("Ho ten:{0}", s);
        Console.WriteLine("Diem Ly:{0}", dl);
        Console.WriteLine("Diem Hoa:{0}", dh);
        Console.WriteLine("Diem Toan:{0}", dt);
    }
    public Double tdl
    {
        set
        { dl = value; }
        get
        { return dl; }
    }
    public Double tdh
    {
        set
        { dh = value; }
        get
        { return dh; }
    }
    public Double tdt
    {
        set
        { dt = value; }
        get
        { return dt; }
    }

}

// bai 5 - BTH 3
class Vecto
{
    private int n;
    private int[] v;
    public Vecto()
    {
        n = 2;
        v = new int[2];
    }
    public Vecto(int n)
    {
        this.n = n;
        v = new int[n];
    }
    public void Nhap()
    {
        Console.WriteLine("Nhap thong tin cua vecto");
        for (int i = 0; i < n; ++i)
        {
            Console.Write("v[{0}]=", i);
            v[i] = int.Parse(Console.ReadLine());
        }
    }
    public void Hien()
    {
        Console.WriteLine("Thong tin cua vecto");
        for (int i = 0; i < n; ++i)
            Console.Write("{0},", i);
    }
    public Vecto Tong(Vecto t2)
    {
        if (this.n == t2.n)
        {
            Vecto t = new Vecto(this.n);
            for (int i = 0; i < n; ++i)
                t.v[i] = this.v[i] + t2.v[i];
            return t;
        }
        else return null;
    }
    public Vecto Hieu(Vecto t2)
    {
        if (this.n == t2.n)
        {
            Vecto t = new Vecto(this.n);
            for (int i = 0; i < n; ++i)
                t.v[i] = this.v[i] - t2.v[i];
            return t;
        }
        else return null;
    }
    public void Saochep(Vecto m)
    {
        n = m.n;
        for (int i = 0; i < n; i++)
        {
            this.v[i] = m.v[i];
        }
    }
    class App
    {
        static void Main()
        {
            Console.WriteLine("Nhap thong tin cho vecto thu nhat");
            Vecto t1 = new Vecto(9); t1.Nhap();
            Console.WriteLine("Nhap thong tin cho vecto thu nhat");
            Vecto t2 = new Vecto(9); t2.Nhap();
            Console.WriteLine("Tong hai vecto");
            Vecto t3 = t1.Tong(t2);
            if (t3 == null)
                Console.WriteLine("Khong tinh tong duc vi hai vecto co kich thuoc khong bang nhau");
            else
            {
                Console.WriteLine("Tong hai vecto");
                t3.Hien();
            }


        }
    }


