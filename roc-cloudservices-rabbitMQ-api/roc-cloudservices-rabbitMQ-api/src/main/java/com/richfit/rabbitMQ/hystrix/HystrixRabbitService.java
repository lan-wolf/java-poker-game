package com.richfit.rabbitMQ.hystrix;

import org.springframework.stereotype.Component;

import com.richfit.rabbitMQ.feign.RabbitFeignService;

import feign.hystrix.FallbackFactory;
@Component
public class HystrixRabbitService implements FallbackFactory<RabbitFeignService>{

	@Override
	public RabbitFeignService create(Throwable arg0) {
		// TODO Auto-generated method stub
		return new RabbitFeignService() {

			@Override
			public String onetoOneP(String queueName, String dataJson) throws Exception {
				// TODO Auto-generated method stub
				return null;
			}

			@Override
			public String onetoOneC(String queueName, String dataJson) throws Exception {
				// TODO Auto-generated method stub
				return null;
			}

			@Override
			public String exchangeP(String queueName, String dataJson, String exchangeName, String routeKey,String type)
					throws Exception {
				// TODO Auto-generated method stub
				return null;
			}

			@Override
			public String exchangeC(String queueName, String dataJson, String exchangeName, String routeKey,String type)
					throws Exception {
				// TODO Auto-generated method stub
				return null;
			}

		
			
		};
	}

}
