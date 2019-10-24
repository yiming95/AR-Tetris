package com.txg.mobile.utils;

import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;

public class SMSInvoke {

	// Send SMS with verificaiton code
	public static void sendVerified(String str, String mobile) {
		final String ACCOUNT_SID = "XXXXXXXX";
		final String AUTH_TOKEN = "XXXXXXXX";
		if(!mobile.contains("+")) {
			mobile = "+61"+mobile;			
		}
		Twilio.init(ACCOUNT_SID, AUTH_TOKEN);

		Message message = Message.creator(new PhoneNumber(mobile), // to
				new PhoneNumber("+????????"), // from
				"[AR Tetris]\nVerification Code is:"+ str).create();

		System.out.println(message.getSid());
	}

}
