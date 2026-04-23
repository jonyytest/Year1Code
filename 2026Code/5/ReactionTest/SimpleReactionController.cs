namespace SimpleReactionMachine
{
    public class SimpleReactionController : IController
    {
        private IState _currentState;
        private IGui _gui;
        private IRandom _rng;
        
        public void Connect(IGui gui, IRandom rng)
        {
            _gui = gui;
            _rng = rng;
        }

        public void Init()
        {
            // Start the machine in the Idle state
            SetState(new IdleState(this)); 
        }

        // Dynamic Dispatch
        public void CoinInserted() { _currentState.CoinInserted(); }

        public void GoStopPressed() { _currentState.GoStopPressed(); }

        public void Tick() { _currentState.Tick(); }

        // Helper method to let states change the active state
        public void SetState(IState newState) 
        {
            _currentState = newState;
        }

        // The base for each state
        public interface IState
        {
            void CoinInserted();
            void GoStopPressed();
            void Tick();
        }

        private class IdleState : IState
        {
           private SimpleReactionController _controller;
           public IdleState(SimpleReactionController controller)
            {
                _controller = controller;
                _controller._gui.SetDisplay("Insert coin");
            }
            public void CoinInserted()
            {
                _controller.SetState(new ReadyState(_controller));
            }
            public void GoStopPressed() {}
            public void Tick() {}
        }

        private class ReadyState : IState
        {
            private SimpleReactionController _controller;
            public ReadyState(SimpleReactionController controller)
            {
                _controller = controller;
                _controller._gui.SetDisplay("Press GO!");
            }
            public void CoinInserted() {}
            public void GoStopPressed()
            {
                _controller.SetState(new WaitState(_controller));
            }
            public void Tick() {}
        }

        private class WaitState : IState
        {
            private SimpleReactionController _controller;
            private int _time;
            public WaitState(SimpleReactionController controller)
            {
                _controller = controller;
                _controller._gui.SetDisplay("Wait...");
                
                _time = _controller._rng.GetRandom(100, 250);
            }
            public void CoinInserted() {}
            public void GoStopPressed()
            {
                _controller.SetState(new IdleState(_controller));
            }
            public void Tick()
            {
                _time--;

                if (_time <= 0)
                {
                    _controller.SetState(new RunningState(_controller));
                }
            }
        }

        private class RunningState : IState
        {
            private SimpleReactionController _controller;
            private int _time = 0;
            public RunningState(SimpleReactionController controller)
            {
                _controller = controller;
                _controller._gui.SetDisplay("0.00");
            }
            public void CoinInserted() {}
            public void GoStopPressed()
            {
                _controller.SetState(new GameOverState(_controller, _time));
            }
            public void Tick()
            {
                _time++;
                _controller._gui.SetDisplay((_time / 100.0).ToString("0.00"));
                if (_time >= 200)
                {
                    _controller.SetState(new GameOverState(_controller, _time));
                }
            }
        }

        private class GameOverState : IState
        {
            private SimpleReactionController _controller;
            private int _time;
            public GameOverState(SimpleReactionController controller, int reactionTime)
            {
                _controller = controller;
                _controller._gui.SetDisplay((reactionTime / 100.0).ToString("0.00"));
                _time = 300;
            }
            public void CoinInserted() {}
            public void GoStopPressed() 
            { 
                _controller.SetState(new IdleState(_controller)); 
            }
            public void Tick()
            {
                _time--;

                if (_time <= 0)
                {
                    _controller.SetState(new IdleState(_controller));
                }
            }
        }
        
    }
}