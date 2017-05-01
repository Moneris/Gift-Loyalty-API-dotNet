namespace Moneris
{
    using System;

	public class TestGiftBatchClose
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
            string store_id = args[0];
            string api_token = args[1];
            string ecr_no = args[2];
	
	        ErnexHttpsPostRequest mpgReq =
	            new ErnexHttpsPostRequest(host, store_id, api_token, 
                    new ErnexBatchclose (ecr_no));
	        try
	        {
	            ErnexReceipt receipt = mpgReq.GetReceipt();
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());

                if ( (receipt.GetReceiptId()).Equals("Global Error Receipt") ) 
	            {
                    Console.WriteLine("TransType = " + receipt.GetTransType());
	    		    Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
	    		    Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
	    		    Console.WriteLine("Message = " + receipt.GetMessage());
	    		    Console.WriteLine("Complete = " + receipt.GetComplete());
	    		    Console.WriteLine("TransDate = " + receipt.GetTransDate());
	    		    Console.WriteLine("TransTime = " + receipt.GetTransTime());
	    		    Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
	            }
	            else
	            {
                    foreach (string term_id in receipt.GetTerminalIDs())
                    {
                        Console.WriteLine("Terminal = " + term_id);
                        Console.WriteLine("Closed = " + receipt.GetClosed(term_id) + "\n");

                        foreach (string cardCode in receipt.GetEcrCardCodes(term_id))
                        {
                            Console.WriteLine("CardCode = " + cardCode);
                            Console.WriteLine("PurchaseCount = " + receipt.GetPurchaseCount(term_id, cardCode));
                            Console.WriteLine("PurchaseTotal = " + receipt.GetPurchaseTotal(term_id, cardCode));
                            Console.WriteLine("PurchaseBenefitTotal = " + receipt.GetPurchaseBenefitTotal(term_id, cardCode));
                            Console.WriteLine("RefundCount = " + receipt.GetRefundCount(term_id, cardCode));
                            Console.WriteLine("RefundTotal = " + receipt.GetRefundTotal(term_id, cardCode));
                            Console.WriteLine("RefundBenefitTotal = " + receipt.GetRefundBenefitTotal(term_id, cardCode));
                            Console.WriteLine("RedemptionCount = " + receipt.GetRedemptionCount(term_id, cardCode));
                            Console.WriteLine("RedemptionTotal = " + receipt.GetRedemptionTotal(term_id, cardCode));
                            Console.WriteLine("RedemptionBenefitTotal = " + receipt.GetRedemptionBenefitTotal(term_id, cardCode));
                            Console.WriteLine("ActivationCount = " + receipt.GetActivationCount(term_id, cardCode));
                            Console.WriteLine("ActivationTotal = " + receipt.GetActivationTotal(term_id, cardCode));
                            Console.WriteLine("CorrectionCount = " + receipt.GetCorrectionCount(term_id, cardCode));
                            Console.WriteLine("CorrectionTotal = " + receipt.GetCorrectionTotal(term_id, cardCode));
                            Console.WriteLine("Error Code = " + receipt.GetErrorCode());
                            Console.WriteLine("Error Message = " + receipt.GetErrorMessage() + "\n");
                        }
                    }
		       
	            }
	        }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
		}
				
	} // end TestGiftBatchClose
}
