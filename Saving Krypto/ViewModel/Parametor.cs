using KryptoInterface;
using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Krypto.ViewModel
{
    class Parametor
    {
        Parametor parametors;
        public Parametor Parametors
        {
            get => parametors;
            private set => parametors = value;
        }

        public Object Paramet { get; private set; }
      //  public IViewModelLayer ViewModelLayer { get; private set; }
     //   public Object ParametMy { get;  set; }
      //  public Object ParametParent { get; set; }
      //  public Object ParametChild { get; set; }
       /* public Parametor(IViewModelLayer ViewModelLayer, Object Paramet = null)
        {
            this.ViewModelLayer = ViewModelLayer;
            this.ParametMy = Paramet;
        }*/
        public Parametor(IViewModelLayer ViewModelLayer)
        {         
            this.Paramet = ViewModelLayer;
        }
        private Parametor(Parametor parametors)
        {
            Parametors = parametors;
        }
        public Parametor AddParametor(Object Paramet)
        {
            Parametor parametor = new Parametor(Parametors) {  Paramet= Paramet, Parametors=this };
            return parametor;
        }

        public T GetObject<T>() where T:class
        {
            
            if(Paramet!=null && Paramet is T найден)
            {
                return найден;
            }
            else if(Parametors!=null)
            {
                return Parametors.GetObject<T>();
            }
            return null;

        }

    }
}
