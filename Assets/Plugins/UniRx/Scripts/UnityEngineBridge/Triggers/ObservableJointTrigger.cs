using System; // require keep for Windows Universal App
using UnityEngine;

namespace UniRx.Triggers
{
    [DisallowMultipleComponent]
    public class ObservableJointTrigger : ObservableTriggerBase
    {
        readonly Subject<float> onJointBreak = new Subject<float>();

        void OnJointBreak(float breakForce)
        {
            onJointBreak.OnNext(breakForce);
        }

        public IObservable<float> OnJointBreakAsObservable()
        {
            return onJointBreak;
        }


        readonly Subject<Joint2D> onJointBreak2D = new Subject<Joint2D>();

        void OnJointBreak2D(Joint2D brokenJoint)
        {
            onJointBreak2D.OnNext(brokenJoint);
        }

        public IObservable<Joint2D> OnJointBreak2DAsObservable()
        {
            return onJointBreak2D;
        }


        protected override void RaiseOnCompletedOnDestroy()
        {
            if (onJointBreak != null)
            {
                onJointBreak.OnCompleted();
            }

            if (onJointBreak2D != null)
            {
                onJointBreak2D.OnCompleted();
            }
        }
    }
}