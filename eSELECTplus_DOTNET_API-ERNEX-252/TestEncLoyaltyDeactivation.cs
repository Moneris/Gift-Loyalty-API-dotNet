namespace Moneris
{
    using System;

	public class TestEncLoyaltyDeactivation
	{
	  public static void Main(string[] args)
	  {
	        string host = "esqa.moneris.com";
            string store_id = args[0];
            string api_token = args[1];
	        string order_id = args[2];
            //Console.WriteLine("Please swipe card");
            //track1 = Console.ReadLine();
            //track2 = Console.ReadLine();
            string track2 = "";
            if (track2.Contains("" +(char)0x1D))
            {
            	track2 = track2.Substring(track2.IndexOf((char)0x1D) + 1);
		}
            if (track2.Contains("" +(char)0x1C))
            {
            	track2 = track2.Substring(0, track2.IndexOf((char)0x1C));
            }
            string info = args[3];
            string language_code = args[4];
            string cvd_value = args[5];
            
	        EncErnexLoyaltyDeactivation ernexLoyaltyDeactivation = new EncErnexLoyaltyDeactivation (order_id, track2, 
                language_code);  

            ernexLoyaltyDeactivation.SetCvdValue(cvd_value); //optional
            ernexLoyaltyDeactivation.SetInfo(info); //optional
            
	        ErnexHttpsPostRequest mpgReq =
	            new ErnexHttpsPostRequest(host, store_id, api_token, ernexLoyaltyDeactivation);

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
                Console.WriteLine("LifetimeBalance = " + receipt.GetLifetimeBalance());
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
                    Console.WriteLine("AmountPrompt = " + receipt.GetAmountPrompt(cardCode));
                    Console.WriteLine("BenefitPrompt = " + receipt.GetBenefitPrompt(cardCode));
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
                        Console.WriteLine("BenefitDescription = " + receipt.GetBenefitDescription(cardCode, recordType));
                        Console.WriteLine("BenefitPromptText = " + receipt.GetBenefitPromptText(cardCode, recordType));
                        Console.WriteLine("AmountPromptText = " + receipt.GetAmountPromptText(cardCode, recordType));
                        Console.WriteLine("InfoPromptText = " + receipt.GetInfoPromptText(cardCode, recordType));
                        Console.WriteLine("InfoPromptText = " + receipt.GetInfoPromptText(cardCode, recordType));
                    }

                }
            }
	        catch (Exception e)
	        {
	            Console.WriteLine(e);
	        }
		}
				
	} // end TestLoyaltyDeactivation
}
