using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_study.Shop1
{
    public delegate void Message(string message);
    internal class Shop1
    {
        private int total_goods;
        Message? message;
        public void AddFuncForMes(Message mes)
        { 
            message += mes;
        }

        public void DelFuncForMes(Message mes)
        {
            message -= mes;
        }

        public Shop1(int total_goods) => this.total_goods = total_goods;

        public int Bue(int goods)
        {
            if (goods > this.total_goods)
            {
                message?.Invoke($"There are not so much goods. There are only {this.total_goods} items.");
                return 0;
            }
            else
            {
                this.total_goods -= goods;
                message?.Invoke($"{goods} items were purchased. {this.total_goods} items left.");
                return goods;
            }
        }

        public void Supply(int goods)
        {
            this.total_goods += goods;
            message?.Invoke($" Warehouse replenished with {goods} items. Total {this.total_goods} items.");
        }
    }
}
