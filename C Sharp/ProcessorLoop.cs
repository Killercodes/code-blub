public class Processor
{
	public CancellationTokenSource CancelToken {get;private set;}
	
	public bool IsRunning {get;private set;}
	
	public event Action<object> OnEvent;
	
	private void Trigger(object str)
	{
		if(OnEvent != null)
			OnEvent.Invoke(str);
	}
	
	public Processor()
	{
		CancelToken = new CancellationTokenSource();
	}
	
	public Processor(int Milliseconds)
	{
		CancelToken = new CancellationTokenSource(Milliseconds);
	}
	
	public Processor(TimeSpan timeSpan)
	{
		CancelToken = new CancellationTokenSource(timeSpan);
	}
	
	public void Start(Action action)
	{
		IsRunning = true;
		CancellationToken ct = CancelToken.Token;
		
		Task.Factory.StartNew(() =>
        {
            while (ct.IsCancellationRequested == false)
            {
				
				action();
                if (ct.IsCancellationRequested)
                {                    
                    Trigger("IsCancellationRequested = true, task canceled");
                    break;
                }
            }
        }, ct);
	}
	
	public void StopAll()
	{		
		CancelToken.Cancel();
		IsRunning = false;
	}
	
}
