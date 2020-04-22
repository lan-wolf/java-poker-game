package com.richfit.rabbit.config;

import java.io.IOException;
import java.net.URISyntaxException;
import java.security.KeyManagementException;
import java.security.NoSuchAlgorithmException;
import java.util.concurrent.TimeoutException;

import com.rabbitmq.client.Connection;
import com.rabbitmq.client.ConnectionFactory;



public class UtilConnecton {
	
 public static Connection getConnectionOne() {
  //定义连接工厂
  ConnectionFactory factory = new ConnectionFactory();
  //设置账号信息，用户名、密码、vhost
  factory.setUsername("root");
  factory.setPassword("root");
  factory.setVirtualHost("vhost_cp");
  //设置服务地址
//  factory.setHost("192.168.10.109");
  factory.setHost("localhost");
  //端口
  factory.setPort(5672);
  // 通过工厂获取连接
  com.rabbitmq.client.Connection conn = null;
  try {
   conn = factory.newConnection();
  } catch (IOException e) {
   e.printStackTrace();
  } catch (TimeoutException e) {
   e.printStackTrace();
  }
  return conn;
 }
 public Connection getConnectionTwo() {
  ConnectionFactory factory = new ConnectionFactory();
  try {
   factory.setUri("amqp://root:root@localhost:5672/vhost_cp");
  } catch (KeyManagementException e1) {
   e1.printStackTrace();
  } catch (NoSuchAlgorithmException e1) {
   e1.printStackTrace();
  } catch (URISyntaxException e1) {
   e1.printStackTrace();
  }
  com.rabbitmq.client.Connection conn = null;
  try {
   conn = factory.newConnection();
  } catch (IOException e) {
   e.printStackTrace();
  } catch (TimeoutException e) {
   e.printStackTrace();
  }
  return conn;
 }
}