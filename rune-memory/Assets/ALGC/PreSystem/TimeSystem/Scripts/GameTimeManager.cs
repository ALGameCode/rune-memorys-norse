using ALGC.utilitySystem;

namespace ALGC.timeSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class GameTimeManager : SingletonMonoBehaviour<GameTimeManager>
    {

        protected override void Awake()
        {
            base.Awake();

        }
        
        private void Start()
        {

        }

        private void Update()
        {

        }

        public void DelayExecuteCoroutine(float waitTime = 1000f)
        {
            StartCoroutine(DelayedExecutionAction.ExecuteDelayedSteps(waitTime));
        }
    }
}