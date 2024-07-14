using Solid.AMTSimulation.Interface;
using Solid.Requests;

namespace Solid.AmtActions.interfaces
{
    internal interface IAction
    {
        public IRequest _request { get; set; }
        public IComscript _comscript { get; set; }
        void PerformAction();
    }
}