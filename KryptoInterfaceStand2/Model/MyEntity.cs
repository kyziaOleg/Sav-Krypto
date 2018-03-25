using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Model
{

    public class PropertyEventArgs : EventArgs
    {
        public Type TypeProperty;
        public Object value;
        public String NameProperty;
    }
    public abstract class MyEntity : IMyEntity
    {
        public virtual int Id { get; set; }
        public IMyEntity Date { get; }
        public MyEntity(IMyEntity date)
        {
            if (date != null)
            {
                Date = date;
                this.Id = date.Id;

               Type type= Date.GetType();
                PropertyInfo[] properetys = type.GetProperties().Where(r=>r.Name!="Date").ToArray();
                foreach(PropertyInfo properety in properetys)
                {
                    if(properety.CanWrite)
                    properety.SetValue(this, properety.GetValue(Date));
                }
                Date.PropertyChanged += Date_ChangedProperty;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged; // это событие совподает с реализацией интерфейса INotifyPropertyChanged потомкам ненедо реализовывать уже его 
        //Приходят с низу
        private void Date_ChangedProperty(object sender, PropertyChangedEventArgs e)
        {
            Type type = this.GetType();
            PropertyInfo properety = type.GetProperty(e.PropertyName);
            if (properety.CanWrite && Date != null)
            {
                Object volueThis = properety.GetValue(this);
                Object volueDate = properety.GetValue(Date);
                if (volueThis != volueDate)
                {
                    properety.SetValue(this, volueDate);
                }
            }

        }

        //Приходят сверху или горизонтально
        protected void OnChangedEntity(String NameProperty)
        {
            Type type = this.GetType();
            PropertyInfo properety = type.GetProperty(NameProperty);
            if (properety.CanWrite && Date!=null)
            {
                Object volueThis = properety.GetValue(this);
                Object volueDate= properety.GetValue(Date);
                if (volueThis != volueDate)
                {
                    properety.SetValue(Date, volueThis);
                }
            }
           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(NameProperty));
                 
        }


        //Переопределить чтобы Устроить проверки
        protected virtual T TryChangProperty<T>(T New, T Old, String nameProperty)
        {
            return New;
        }




        public override string ToString()
        {
            return $"Id={Id}";
        }


    }




}
