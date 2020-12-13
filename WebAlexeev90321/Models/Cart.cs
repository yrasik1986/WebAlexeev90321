using System;
using System.Collections.Generic;
using System.Linq;
using WebAlexeev90321.DAL.Entities;

namespace WebAlexeev90321.Models
{
    public class Cart
    {

        public Dictionary<int, CartItem> Items { get; set; }

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public int Count
        {
            get { return Items.Sum(item => item.Value.Quantity); }
        }

        public int Price
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.RadioComponent.Price);
            }
        }
        /// <param name="radioComponent">добавляемый объект</param>
        public virtual void AddToCart(RadioComponent radioComponent)
        {
            if (Items.ContainsKey(radioComponent.RadioComponentId))
                Items[radioComponent.RadioComponentId].Quantity++;
            // иначе - добавить объект в корзину

            else
                Items.Add(radioComponent.RadioComponentId, new CartItem
                {
                    RadioComponent = radioComponent,
                    Quantity = 1
                });
        }
        public virtual void RemoveFromCart(int id)

        {
            Items.Remove(id);
        }
        public virtual void ClearAll()
        {
            Items.Clear();
        }

    }

    public class CartItem
    {
        public RadioComponent RadioComponent { get; set; }
        public int Quantity { get; set; }
    }
}
