using KryptoInterface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KryptoInterface.Model
{
    public abstract class Modul : IModul 
    {
        IModul nextEternalModul;
        protected IModul NextEternalModul
        {
            get
            {
                return nextEternalModul;
            }
            set
            {
                if (nextEternalModul == null)
                {
                    nextEternalModul = value;
                }
            }
        }
        IModul requestInsideModul;
        protected IModul RequestInsideModul
        {
            get
            {
                return requestInsideModul;
            }
            set
            {
                if (requestInsideModul == null)
                {
                    requestInsideModul = value;
                }
            }
        }
        IModul answerInsideModul;
        protected IModul AnswerInsideModul
        {
            get
            {
                return answerInsideModul;
            }
            set
            {
                if (answerInsideModul == null)
                {
                    answerInsideModul = value;
                }
            }
        }
        public Modul(IModul modul)
        {
            NextEternalModul = modul;
        }


       /* public IComondModul<IMyEntity> GetComondModul(Type type, TypeComond action, IEnumerable<IMyEntity> date) 
        {
            return  ComondModul<IMyEntity>.GetComond(type, action, date); 
        }*/

        protected virtual IComondModul<IMyEntity> СommandStart(IComondModul<IMyEntity> comond) 
        {
            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandStartInsideModulRequest(IComondModul<IMyEntity> comond) 
        {
            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandEndInsideModulRequest(IComondModul<IMyEntity> comond) 
        {
            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandStartEternalModul(IComondModul<IMyEntity> comond) 
        {
            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandEndEternalModul(IComondModul<IMyEntity> comond) 
        {

            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandStartInsideModulAnswer(IComondModul<IMyEntity> comond) 
        {
            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandEndInsideModulAnswer(IComondModul<IMyEntity> comond) 
        {
            return comond;
        }
        protected virtual IComondModul<IMyEntity> СommandEnd(IComondModul<IMyEntity> comond)
        {
            return comond;
        }
        public IComondModul<IMyEntity> Сommand(IComondModul<IMyEntity> comond) 
        {
            IComondModul<IMyEntity> date = СommandStart(comond);
            if (RequestInsideModul is IModul Reposit1)
            {
                date = СommandStartInsideModulRequest(date);
                date = Reposit1.Сommand(date);
                date = СommandEndInsideModulRequest(date);
            }
            if (NextEternalModul is IModul Reposit2)
            {
                if (comond.Visit == TypeVisit.All || (comond.Visit == TypeVisit.FirstAnswer && comond.Answer == null))
                {
                    date = СommandStartEternalModul(date);
                    date = Reposit2.Сommand(date);
                    date = СommandEndEternalModul(date);
                }
                
            }
            if (AnswerInsideModul is IModul Reposit3)
            {
                date = СommandStartInsideModulAnswer(date);
                date = Reposit3.Сommand(date);
                date = СommandEndInsideModulAnswer(date);
            }
            date = СommandEnd(date);
            return date;
        }
    }
}
