package com.txg.mobile.test;
import org.junit.Test;

import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;
import com.txg.mobile.utils.SMSInvoke;

public class SmsSender {
    @Test
    public void sendMessage() {
    	SMSInvoke.sendVerified("123456", "0403408927");
    }
}