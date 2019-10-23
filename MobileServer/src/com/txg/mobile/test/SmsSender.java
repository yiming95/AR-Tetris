package com.txg.mobile.test;
import com.twilio.Twilio;
import com.twilio.rest.api.v2010.account.Message;
import com.twilio.type.PhoneNumber;

public class SmsSender {
    // Find your Account Sid and Auth Token at twilio.com/console
    public static final String ACCOUNT_SID =
            "AC0342aad9d0248e1da29b7d847f89c107";
    public static final String AUTH_TOKEN =
            "9ffc18e0ee9de0b58ca4793085005d99";

    public static void main(String[] args) {
        Twilio.init(ACCOUNT_SID, AUTH_TOKEN);

        Message message = Message
                .creator(new PhoneNumber("+610431683781"), // to
                        new PhoneNumber("+15176825513"), // from
                        "Where's Wallace?")
                .create();

        System.out.println(message.getSid());
    }
}