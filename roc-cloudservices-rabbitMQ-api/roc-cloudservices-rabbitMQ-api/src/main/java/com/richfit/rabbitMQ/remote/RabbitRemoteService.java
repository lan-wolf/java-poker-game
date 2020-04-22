package com.richfit.rabbitMQ.remote;

import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;


public interface RabbitRemoteService {

    public final static String PATH ="/rabbit";

    
	/**
     *
     * 1对1
     * @return
	 * @throws Exception 
     */
	@RequestMapping(value=PATH+"/oneToone",method=RequestMethod.POST)
    String  onetoOneP(@RequestParam("queueName")String queueName,@RequestParam("dataJson")String dataJson) throws Exception;
	/**
	 *
	 * 1对1
	 * @return
	 * @throws Exception 
	 */
	@RequestMapping(value=PATH+"/onetoOne2",method=RequestMethod.POST)
	String  onetoOneC(@RequestParam("queueName")String queueName,@RequestParam("dataJson")String dataJson) throws Exception;
	/**
	 *
	 * 交换机1对1
	 * @return
	 * @throws Exception 
	 */
	@RequestMapping(value=PATH+"/exchangeP",method=RequestMethod.POST)
	String  exchangeP(@RequestParam("queueName")String queueName,@RequestParam("dataJson")String dataJson,@RequestParam("exchange")String exchangeName,@RequestParam("routeKey")String routeKey,@RequestParam("type")String type) throws Exception;
	/**
	*
	* 交换机1对1
	* @return
	* @throws Exception 
	*/
	@RequestMapping(value=PATH+"/exchangeC",method=RequestMethod.POST)
	String  exchangeC(@RequestParam("queueName")String queueName,@RequestParam("dataJson")String dataJson,@RequestParam("exchange")String exchangeName,@RequestParam("routeKey")String routeKey,@RequestParam("type")String type) throws Exception;
	
}
