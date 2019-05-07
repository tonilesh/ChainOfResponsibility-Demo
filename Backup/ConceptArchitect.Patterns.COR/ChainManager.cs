using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConceptArchitect.Patterns.COR
{
    public class ChainManager<T>:IResponsible<T>
    {
        List<IResponsible<T>> responsibles = new List<IResponsible<T>>();



        private IResponsible<T> _processor=null;
        public IResponsible<T> Processor
        {
            get { return _processor; }

            private set { _processor = value; }
        }
					
			
			

        public ChainResult Action(T obj)
        {
            

            foreach(IResponsible<T> responsible in responsibles)
            {
                ChainResult result=responsible.Action(obj);
                if (result == ChainResult.Sucess)
                {
                    Processor = responsible;
                    return ChainResult.Sucess;
                }
            }

            return ChainResult.Failure;
        }

        public void Insert(IResponsible<T> responsible)
        {
            responsibles.Add(responsible);
        }

        public void Insert(IResponsible<T> responsible, int pos)
        {
            responsibles.Insert(pos, responsible);
        }

        public void Remove(IResponsible<T> responsible)
        {
            if (responsibles.Contains(responsible))
                responsibles.Remove(responsible);
        }
    }


}
