using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Model
{
     
   

    public interface ITrackingСhangesModul
    {

    }

    //Сохроняет всё что выдаёт Repository и отдаёт данные нужного типа при запросе не передавая запорс Repository 
    public class TrackingСhangesModul : Modul, ITrackingСhangesModul
    {
       

        public TrackingСhangesModul(IModul modul) : base(modul)
        {
           

        }
        protected override IComondModul<IMyEntity> СommandEnd(IComondModul<IMyEntity> comond)
        {
            if (comond.Action == TypeComond.Get || comond.Action == TypeComond.Сreate)
            {
                foreach (IMyEntity Iter in comond.Answer)
                {
                    Iter.PropertyChanged += Iter_ChangedEntity;
                }
            }
            else if (comond.Action == TypeComond.Remove)
            {
                foreach (IMyEntity Iter in comond.Answer)
                {
                    Iter.PropertyChanged -= Iter_ChangedEntity;
                }
            }
            if (comond.Action == TypeComond.Сreate || comond.Action == TypeComond.Remove)
            {
                Save();
            }
            return base.СommandEnd(comond);
        }
        void Save()
        {
            IComondModul<IMyEntity> mudul = new ComondMudul<IMyEntity>(TypeComond.Save, null);
            Сommand(mudul);
        }
        private void Iter_ChangedEntity(object sender, EventArgs e)
        {
            Save();
        }
    }
}
