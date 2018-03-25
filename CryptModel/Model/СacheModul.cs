using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KryptoInterface.Model;

namespace KryptoInterface.Model
{
    public interface IСacheModul
    {

    }

    //Сохроняет всё что выдаёт Repository и отдаёт данные нужного типа при запросе не передавая запорс Repository 
    public class СacheModul : Modul, IСacheModul
    {
        IList<IMyEntity> cacheEntity;

        public СacheModul(IModul modul) : base(modul)
        {
            cacheEntity = new List<IMyEntity>();

        }
        protected override IComondModul<IMyEntity> СommandStart(IComondModul<IMyEntity> comond)
        {
            if (comond.Action == TypeComond.Get)
            {
              IList<IMyEntity> entity=  cacheEntity.Where(r => r.GetType() == comond.GetType()).ToList();
                if (entity.Count() > 0)
                {
                    comond.SetAnswer(entity);
                }
            }
            return base.СommandStart(comond);
        }
        protected override IComondModul<IMyEntity> СommandEnd(IComondModul<IMyEntity> comond)
        {
           
            if (comond.Answer != null && (comond.Action== TypeComond.Get|| comond.Action == TypeComond.Сreate))
            {
                foreach (IMyEntity entity in comond.Answer)
                {

                    IMyEntity найден = cacheEntity.Where(r => r.Id == entity.Id && r.GetType() == entity.GetType()).FirstOrDefault();
                    if (найден == null)
                    {
                        cacheEntity.Add(entity);
                    }


                }
            }
            else if(comond.Answer != null &&  comond.Action == TypeComond.Remove)
            {
                foreach (IMyEntity entity in comond.Answer)
                {

                    if (cacheEntity.Contains(entity))
                    {
                        cacheEntity.Remove(entity);
                    }

                }
            }

            return base.СommandEnd(comond);
        }

    }
}
