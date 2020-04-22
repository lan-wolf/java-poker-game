package com.richfit.rabbit.service;

import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.concurrent.TimeoutException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.amqp.core.AmqpTemplate;
import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.DirectExchange;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.rabbitmq.client.BuiltinExchangeType;
import com.rabbitmq.client.Channel;
import com.rabbitmq.client.Connection;
import com.rabbitmq.client.Consumer;
import com.rabbitmq.client.DefaultConsumer;
import com.rabbitmq.client.Envelope;
import com.richfit.rabbit.config.UtilConnecton;
import com.richfit.rabbitMQ.feign.RabbitFeignService;

import io.swagger.annotations.Api;

import org.springframework.amqp.core.Queue;
import org.springframework.amqp.rabbit.annotation.Exchange;
import org.springframework.amqp.rabbit.core.RabbitAdmin;
import org.springframework.amqp.rabbit.core.RabbitTemplate;

@RestController
@Service
@Component
public class MqServiceProducer implements RabbitFeignService {
	private static final Logger logger = LoggerFactory.getLogger(MqServiceProducer.class);

	private String msg= "";
	@Autowired
    private AmqpTemplate rabbitTemplate;
	@Autowired
    private RabbitAdmin rabbitAdmin;
	@Autowired
	private RabbitTemplate rabbitTemplates;
	//one to one
	@Override
	public String onetoOneP(String queueName,String dataJson) throws IOException, TimeoutException {
		//获取MQ链接工具类
		UtilConnecton util = new UtilConnecton();
		//获取到链接及MQ通道
		Connection conn = util.getConnectionOne();
		//从连接中创建通道
		Channel channel = conn.createChannel();
		//声明（创建）队列
		channel.queueDeclare(queueName,false,false,false,null);
		//消息内容
		String message = dataJson;
		channel.basicPublish("", queueName, null, message.getBytes());
		logger.info("onetoOneP sender a massage : {}" , message);
//		System.out.println(" Sender a massage : '" + message + "'");
		//关闭通道和链接
		channel.close();
		conn.close();
        return " onetoOneP sender a massage : '" + message + "'";
	}
	
	@Override
	public String onetoOneC(String queueName, String dataJson) throws Exception {
		//获取MQ链接工具类
		  UtilConnecton util = new UtilConnecton();
		  //获取到链接及MQ通道
		  Connection conn = util.getConnectionOne();
		  //从链接中创建通道
		  Channel channel = conn.createChannel();
		  //声明队列
		  channel.queueDeclare(queueName, false, false, false, null);
		//通过回调生成消费者
		  Consumer consumer = new DefaultConsumer(channel) {
		            @Override
		            public void handleDelivery(String consumerTag, Envelope envelope,
		                    com.rabbitmq.client.AMQP.BasicProperties properties, byte[] body) throws IOException {
		                
		                //获取消息内容然后处理
		            	msg= new String(body, "UTF-8");
		            	logger.info("onetoOneC receiver a massage : {}" , msg);
//		               System.out.println("获取收到的内容为："+msg);
		            }
		        };
		        //消费消息
		        channel.basicConsume(queueName, true, consumer);
		    	return "onetoOneC receiver a massage :" + msg;
		 }
	/**
	 * exchange direct type binding qeueue for producer
	 */
	@Override
	public String exchangeP(String queueName, String dataJson, String exchangeName,String routeKey,String type) throws Exception {
		//获取MQ链接工具类
		UtilConnecton util = new UtilConnecton();
		//获取到连接以及mq通道      方式一
		com.rabbitmq.client.Connection conn = util.getConnectionOne();
//		//获取到连接以及mq通道     方式二
//		com.rabbitmq.client.Connection conn = util.getConnectionTwo();
		//从连接中创建通道
		Channel channel = conn.createChannel();
		if("direct".equals(BuiltinExchangeType.DIRECT)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.DIRECT,true);
		}
		if("fanout".equals(BuiltinExchangeType.FANOUT)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.FANOUT,true);
		}
		if("topic".equals(BuiltinExchangeType.TOPIC)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.TOPIC,true);
		}
		if("headers".equals(BuiltinExchangeType.HEADERS)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.HEADERS,true);
		}
		
		//声明（创建）队列
		channel.queueDeclare(queueName,false,false,false,null);
		//队列和交换器进行绑定
		channel.queueBind(queueName, exchangeName, routeKey);
		channel.basicPublish(exchangeName, routeKey, null, dataJson.getBytes());
		logger.info("exchangeP sender a massage : {}" , dataJson);
		//关闭通道和链接
		channel.close();
		conn.close();
		return " exchangeP sender a massage : " + dataJson;
	}
	/**
	 * exchange direct type binding qeueue for receiver
	 */ 
	@Override
	public String exchangeC(String queueName, String dataJson, String exchangeName,String routeKey,String type) throws Exception {
		//获取MQ链接工具类
		UtilConnecton util = new UtilConnecton();
		//获取到链接及MQ通道
		Connection conn = util.getConnectionOne();
		//从链接中创建通道
		Channel channel = conn.createChannel();
		if("direct".equals(BuiltinExchangeType.DIRECT)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.DIRECT,true);
		}
		if("fanout".equals(BuiltinExchangeType.FANOUT)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.FANOUT,true);
		}
		if("topic".equals(BuiltinExchangeType.TOPIC)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.TOPIC,true);
		}
		if("headers".equals(BuiltinExchangeType.HEADERS)) {
			//声明交换器
			channel.exchangeDeclare(exchangeName, BuiltinExchangeType.HEADERS,true);
		}
		//声明队列
		channel.queueDeclare(queueName, false, false, false, null);
		//队列和交换器进行绑定
		channel.queueBind(queueName, exchangeName, routeKey);
		logger.info(" **** keep alive ,waiting for messages, and then deal them");
		//通过回调生成消费者
		Consumer consumer = new DefaultConsumer(channel) {
            @Override
            public void handleDelivery(String consumerTag, Envelope envelope,
                    com.rabbitmq.client.AMQP.BasicProperties properties, byte[] body) throws IOException {
                
                //获取消息内容然后处理
                String msg = new String(body, "UTF-8");
                logger.info("exchangeC get a message : {} " , msg );
            }
        };
        //消费消息
        channel.basicConsume(queueName, true, consumer);
        return " exchangeC get a messag  :" + msg;
	}
	
	/**
	 * exchange top type binding qeueue for receiver
	 */
	

}
