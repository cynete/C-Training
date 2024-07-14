using Solid.AmtActions.interfaces;

namespace Solid.AmtActions
{
    internal class Helper
    {
        private IAction _action { get; set; }

        public Helper(IAction action)
        {
            _action = action;
        }

        public void ExecuteAction()
        {
            _action.PerformAction();
        }
    }
}
