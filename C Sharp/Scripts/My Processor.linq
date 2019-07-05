<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
/*
	var ts = new CancellationTokenSource();
        //CancellationToken ct = ts.Token;       
	   Process(ts);
	   Thread.Sleep(5000);
	   ts.Cancel();*/
	   
	var p = new Processor();
	var c = p.CancelToken;
	p.OnEvent += (e) => Console.WriteLine(" - {0}",e);
	p.Start(()=> { Thread.Sleep(100); Console.WriteLine("{0} - {1}", DateTime.Now.ToString("s"),"process 1 running");});
	p.Start(()=> { Thread.Sleep(100); Console.WriteLine("{0} - {1}", DateTime.Now.ToString("s"),"process 2 running");});
	Thread.Sleep(5000);
	p.StopAll();
}

// Define other methods and classes here


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

void ProcessExample(CancellationTokenSource ts)
{
	CancellationToken ct = ts.Token;
	 Task.Factory.StartNew(() =>
        {
            while (ct.IsCancellationRequested == false)
            {
				Console.WriteLine("working.. IsCancelled=" + ct.IsCancellationRequested);
                // do some heavy work here
                Thread.Sleep(100);
                if (ct.IsCancellationRequested)
                {
                    // another thread decided to cancel
                    Console.WriteLine("IsCancellationRequested = true, task canceled");
                    break;
                }
            }
        }, ct);

        // Simulate waiting 3s for the task to complete
        //Thread.Sleep(3000);

        // Can't wait anymore => cancel this task 
        //ts.Cancel();
        //Console.WriteLine("cancelled with ts.Cancel()");
}