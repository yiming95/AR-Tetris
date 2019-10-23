package com.txg.mobile.utils;

import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;

public class SMSInvoke {

	// Send SMS with verificaiton code
	public static void sendVerified(String str, String mobile) {
		final String ACCOUNT_SID = "AC0342aad9d0248e1da29b7d847f89c107";
		final String AUTH_TOKEN = "9ffc18e0ee9de0b58ca4793085005d99";
		if(!mobile.contains("+")) {
			mobile = "+61"+mobile;			
		}
		Twilio.init(ACCOUNT_SID, AUTH_TOKEN);

		Message message = Message.creator(new PhoneNumber(mobile), // to
				new PhoneNumber("+15176825513"), // from
				"[AR Tetris]\nVerification Code is:"+ str).create();

		System.out.println(message.getSid());
	}

}
