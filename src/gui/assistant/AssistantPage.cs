using System;
using System.Windows.Forms;

namespace Rasterbator
{
	public abstract class AssistantPage : TabPage
	{	
		public AssistantControl ParentControl {
			get { return (Parent.Parent as AssistantControl); }
		}
		
		public virtual String getContinueButtonText ()
		{
			return "Continue >";
		}
		
		public virtual Boolean isOkayToLeave ()
		{
			return true;
		}
		
		public virtual void afterLeaveHandler ()
		{
		}
		
		public virtual void beforeShowHandler ()
		{
		}
	}
}