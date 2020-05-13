using System;
using System.Security.Principal;

namespace PW6
{
    public abstract class Boss
    {
        protected float confirmedAmount;

        protected Boss nextBoss;

        public void ApproveRequest(float requestedAmount)
        {
            if (requestedAmount < confirmedAmount)
            {
                Write(requestedAmount);
            }
            else
            {
                nextBoss = new BossLvl2(confirmedAmount);
                Write(requestedAmount);
            }
        }

        abstract protected void Write(float requestedAmount);
    }

    public class BossLvl1 : Boss
    {

        public BossLvl1(float requestedAmount) => this.confirmedAmount = 500;

        protected override void Write(float requestedAmount)
        {
            Console.WriteLine("Boos1: OK. That's your " + requestedAmount);
        }
    }

    class BossLvl2 : Boss
    {
        public BossLvl2(float requestedAmount) => this.confirmedAmount = requestedAmount;

        protected override void Write(float requestedAmount)
        {
            Console.WriteLine("Boos2: OK. That's your " + requestedAmount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GiveMeMoney(600);
        }

        private static void GiveMeMoney(float ammount)
        {
            Boss boss = new BossLvl1(ammount);
            boss.ApproveRequest(ammount);
        }
    }
}
