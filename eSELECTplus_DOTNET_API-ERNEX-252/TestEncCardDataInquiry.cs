namespace Moneris
{
    using System;

	public class TestCardDataInquiry
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
            string store_id = "monca00001";
            string api_token = "giftguy";
	        string track2 = args[0];
            if (track2.Contains("" +(char)0x1D))
            {
            	track2 = track2.Substring(track2.IndexOf((char)0x1D) + 1);
		}
            if (track2.Contains("" +(char)0x1C))
            {
            	track2 = track2.Substring(0, track2.IndexOf((char)0x1C));
            }
            //Console.WriteLine("Please swipe card");
            //track1 = Console.ReadLine();
            //track2 = Console.ReadLine();
            string pan = "0311040000001000234";
            string expdate = "1111";
	
	        ErnexHttpsPostRequest mpgReq =
	            new ErnexHttpsPostRequest(host, store_id, api_token, 
                    new EncErnexCardDataInq (track2));
	        try
	        {
	            ErnexReceipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("HostReferenceNum = " + receipt.GetHostReferenceNum());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransCardCode = " + receipt.GetTransCardCode());
                Console.WriteLine("TransCardType = " + receipt.GetTransCardType());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("HostTotals = " + receipt.GetHostTotals());
                Console.WriteLine("DisplayText = " + receipt.GetDisplayText());
                Console.WriteLine("ReceiptText = " + receipt.GetReceiptText());
                Console.WriteLine("CardHolderName = " + receipt.GetCardHolderName());
                Console.WriteLine("VoucherType = " + receipt.GetVoucherType());
                Console.WriteLine("VoucherText = " + receipt.GetVoucherText());
                Console.WriteLine("InitialAmount = " + receipt.GetInitialAmount());
                Console.WriteLine("InitialBalance = " + receipt.GetInitialBalance());
                Console.WriteLine("BatchNo = " + receipt.GetBatchNo());
                Console.WriteLine("CurrentBalance = " + receipt.GetCurrentBalance());
                Console.WriteLine("Benefit = " + receipt.GetBenefit());
                Console.WriteLine("Language = " + receipt.GetLanguage());
                Console.WriteLine("Error Code = " + receipt.GetErrorCode());
                Console.WriteLine("Error Message = " + receipt.GetErrorMessage());
                Console.WriteLine("ActivationCharge = " + receipt.GetActivationCharge());
                Console.WriteLine("RemainingBalance = " + receipt.GetRemainingBalance());
                Console.WriteLine("CardStatus = " + receipt.GetCardStatus());

                foreach (string cardCode in receipt.GetCardCodes())
                {
                    Console.WriteLine("cardCode = " + cardCode);
                    Console.WriteLine("CardCardType = " + receipt.GetCardCardType(cardCode));
                    Console.WriteLine("CheckMod10 = " + receipt.GetCheckMod10(cardCode));
                    Console.WriteLine("CheckLanguage = " + receipt.GetCheckLanguage(cardCode));
                    Console.WriteLine("CVCPrompt = " + receipt.GetCVCPrompt(cardCode));
                    Console.WriteLine("InfoPrompt = " + receipt.GetInfoPrompt(cardCode));
                    Console.WriteLine("InitialAmountPrompt = " + receipt.GetInitialAmountPrompt(cardCode));
                    Console.WriteLine("RefundAllowed = " + receipt.GetRefundAllowed(cardCode));
                    Console.WriteLine("CardLengthMinimum = " + receipt.GetCardLengthMinimum(cardCode));
                    Console.WriteLine("CardLengthMaximum = " + receipt.GetCardLengthMaximum(cardCode));
                    Console.WriteLine("LowBIN1 = " + receipt.GetLowBIN1(cardCode));
                    Console.WriteLine("HighBIN1 = " + receipt.GetHighBIN1(cardCode));
                    Console.WriteLine("LowBIN2 = " + receipt.GetLowBIN2(cardCode));
                    Console.WriteLine("HighBIN2 = " + receipt.GetHighBIN2(cardCode));
                    Console.WriteLine("LowBIN3 = " + receipt.GetLowBIN3(cardCode));
                    Console.WriteLine("HighBIN3 = " + receipt.GetHighBIN3(cardCode));
                    Console.WriteLine("LowBIN4 = " + receipt.GetLowBIN4(cardCode));
                    Console.WriteLine("HighBIN4 = " + receipt.GetHighBIN4(cardCode) + "\n");

                    foreach (string recordType in receipt.GetRecordType(cardCode))
                    {
                        Console.WriteLine("recordType = " + recordType);
                        Console.WriteLine("CardDescription = " + receipt.GetCardDescription(cardCode, recordType));
                        Console.WriteLine("InfoPromptText = " + receipt.GetInfoPromptText(cardCode, recordType));
                    }

                }
            }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
		}
				
	} // end TestInitialization
}
