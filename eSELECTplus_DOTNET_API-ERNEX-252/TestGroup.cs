namespace Moneris
{
    using System;

	public class TestGroup
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
            string store_id = args[0];
            string api_token = args[1];
            string order_id = args[2];
            string txn_number = args[3];
            string group_ref_num = args[4];
            string group_type = args[5];
            	
	        ErnexHttpsPostRequest mpgReq =
	            new ErnexHttpsPostRequest(host, store_id, api_token, 
                    new Group (order_id, txn_number, group_ref_num, group_type));
	        try
	        {
	            ErnexReceipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                                
            }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
		}
				
	} // end TestInitialization
}
