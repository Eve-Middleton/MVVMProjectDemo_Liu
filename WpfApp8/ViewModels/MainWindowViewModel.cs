
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WpfApp8.Models;
using WpfApp8.Services;

namespace WpfApp8.ViewModels
{
    internal class MainWindowViewModel

    {
        /// <summary>
        /// mainwindow Vm
        /// </summary>
        public class MainWindowVodelModel : BindableBase
        {
            /// <summary>
            /// 订餐命令
            /// </summary>
            public DelegateCommand PlaceOrderCommand { get; set; }
            /// <summary>
            /// 选中命令
            /// </summary>
            public DelegateCommand SelectMenuItemCommand { get; set; }

            //私有字段
            private int count;
            //共有属性
            public int Count
            {
                get { return count; }
                set
                {
                    count = value;
                    this.RaisePropertyChanged("Count");
                }
            }

            private Restaurant restaurant;

            public Restaurant Restaurant
            {
                get { return restaurant; }
                set
                {
                    restaurant = value;
                    this.RaisePropertyChanged("Restaurant");
                }
            }
            private List<DishMenuItemViewModel> dishMenu;
            public List<DishMenuItemViewModel> DishMenu
            {
                get { return dishMenu; }
                set
                {
                    dishMenu = value;
                    this.RaisePropertyChanged("DishMenu");
                }
            }
            public MainWindowVodelModel()
            {
                this.LoadResturant();
                this.LoadDishMenu();
                this.PlaceOrderCommand = new DelegateCommand(new Action(this.PlaceOrderCommandExcute));
                this.SelectMenuItemCommand = new DelegateCommand(new Action(this.SelectMenuItemExcute));


            }
            private void LoadResturant()
            {
                this.Restaurant = new Restaurant();
                this.Restaurant.Name = "Craze大象";
                this.Restaurant.Address = "北京市海淀区万泉河路紫金庄园1号楼";
                this.Restaurant.Phone = "13679112984";
            }
            private void LoadDishMenu()
            {
                XmlDataService ds = new XmlDataService();
                var dishes = ds.GetAllDishes();
                this.DishMenu = new List<DishMenuItemViewModel>();
                foreach (var dish in dishes)
                {
                    DishMenuItemViewModel item = new DishMenuItemViewModel();
                    item.Dish = dish;
                    this.DishMenu.Add(item);
                }
            }
            private void PlaceOrderCommandExcute()
            {
                var selectedDishes = this.DishMenu.Where(t => t.IsSelected == true).Select(t => t.Dish.Name).ToList();
                IOrderService orderService = new MockOrderService();
                orderService.PlaceOrder(selectedDishes);
                MessageBox.Show("订餐成功");
            }
            private void SelectMenuItemExcute()
            {
                this.Count = this.DishMenu.Count(t => t.IsSelected == true);
            }
        }

    }
}
