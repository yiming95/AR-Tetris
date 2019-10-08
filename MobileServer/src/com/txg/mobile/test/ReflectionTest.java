package com.txg.mobile.test;

import org.junit.Test;

public class ReflectionTest {

	@Test
	public void reflectTest() {
		Object[] list = {10, "DENG", 123.45};
		for(Object o: list) {
			System.out.println(o.getClass().toString());
		}
	}
}
