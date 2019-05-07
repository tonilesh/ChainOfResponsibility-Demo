using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConceptArchitect.Patterns.COR;

namespace CORApp01
{
    class ObjectManager:IResponsible<Object>
    {
        

        private ChainResult _result;
        public ChainResult Result
        {
            get { return _result; }

            set { _result = value; }
        }


        public ObjectManager(ChainResult result  )
        {
            Result = result;
        }

        public ObjectManager():this(ChainResult.Sucess)
        {

        }
			
        
        public ChainResult Action(object action)
        {
            Console.WriteLine("object is {0} type is {1}",action,action.GetType().Name);
            return Result;
                
        }
    }

    class StringManager : IResponsible<Object>
    {
        

        public ChainResult Action(object action)
        {
            if (action is String)
            {
                Console.WriteLine("'{0}' is a string with length {1}",
                                action, ((string)action).Length);

                return ChainResult.Sucess;
            }
            else
                return ChainResult.Failure;
            
        }

        
    }

    class NumberManager : IResponsible<Object>
    {

        

        public ChainResult Action(object action)
        {
            try
            {
                double value = double.Parse(action.ToString());
                Console.WriteLine("the value is "+value);
                return ChainResult.Sucess;
            }
            catch
            {
                return ChainResult.Failure;
            }
        }

        
    }

    class ObjectCounter : IResponsible<Object>
    {
       

        private int _count=0;
        public int Count
        {

            get { return _count; }

            set { _count = value; }
        }

        public ChainResult Action(object action)
        {
            Count++;
            return ChainResult.Pass; //I processed it. and Passed it
        }

        
    }
}
