package com.richfit.rabbitMQ.feign;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.stereotype.Component;

import com.richfit.rabbitMQ.hystrix.HystrixRabbitService;
import com.richfit.rabbitMQ.remote.RabbitRemoteService;



@FeignClient(name = "rabbit-services", primary = false,fallbackFactory=HystrixRabbitService.class)
public interface RabbitFeignService extends RabbitRemoteService{

}
