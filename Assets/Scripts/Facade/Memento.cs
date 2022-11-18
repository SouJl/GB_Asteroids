using GB_Asteroids.Memento;

namespace GB_Asteroids.Facade
{
    public class Memento
    {
        private MementoController _mementoController;

        public Memento(RecodView view) 
        {
            _mementoController = new MementoController(view.RecordTime, view.TargetTransform, view.TargetRigidBody);
        }

        public IExecute GetController() => _mementoController;
    }
}
