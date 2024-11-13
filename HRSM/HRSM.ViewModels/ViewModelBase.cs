using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRSM.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //1.
        //protected void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        //3.
        
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //2.

        //protected void OnPropertyChanged<T>(Expression<Func<T>> action)
        //{
        //    string proName = GetPropertyName(action);
        //    OnPropertyChangedEvent(proName);
        //}



        //protected void OnPropertyChangedEvent(string proName)
        //{
        //    if(PropertyChanged!=null)
        //    {
        //        PropertyChangedEventArgs e = new PropertyChangedEventArgs(proName);
        //        PropertyChanged(this, e);
        //    }
        //}


        ///// <summary>
        ///// 获取属性名
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="action"></param>
        ///// <returns></returns>
        //private static string GetPropertyName<T>(Expression<Func<T>> action)
        //{
        //    var expression = (MemberExpression)action.Body;
        //    string proName = expression.Member.Name;
        //    return proName;
        //}

        /// <summary>
        /// 窗口关闭命令
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                RelayCmmand cmd = new RelayCmmand(o => {
                    Type type = o.GetType();
                    MethodInfo mi = type.GetMethod("Close");
                    mi.Invoke(o, null);
                });
                return cmd;
            }
        }

        public string assName = "HRSM.DXHouseApp";
        /// <summary>
        /// 获取指定类型名的UI对象的Type
        /// </summary>
        /// <param name="fullTypeName"></param>
        /// <returns></returns>
        public Type GetUITypeByName(string fullTypeName)
        {
            Type type = Assembly.Load(assName).GetType(fullTypeName);
            return type;
        }

        /// <summary>
        /// 返回指定类的指定方法名
        /// </summary>
        /// <param name="type"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public MethodInfo GetMethod(Type type,string methodName,bool isPublic)
        {
            if (isPublic)
                return type.GetMethod(methodName);
            else
                return type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        /// <summary>
        /// 设置指定的属性的值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="proName"></param>
        /// <returns></returns>
        public void SetPropertyVal(Type type,object obj, string proName,object val)
        {
            PropertyInfo pro = type.GetProperty(proName);
            pro.SetValue(obj, val);
        }

        public object GetPropertyVal(Type type, object obj, string proName)
        {
            PropertyInfo pro = type.GetProperty(proName);
            return pro.GetValue(obj);
        }
    }
}
