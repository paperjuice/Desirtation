# Introduction
   Some demo text to try the functionality


|  Item 1  |  Item 2. |
|:---------|:---------|
|1. stuff1 |1. stuff1 |
|2. bam    |2. stuff2 |



   Some code to put in a snippet 
```ruby
  defp setup_channel do
    {:ok, connection} = AMQP.Connection.open(@mq_config)
    {:ok, channel} = AMQP.Channel.open(connection)
    AMQP.Queue.declare(channel, @queue_name, durable: true)
    channel
  end
```
   Some random image below

![](https://www.w3schools.com/css/img_fjords.jpg "Image")

And this is just a [link] (www.google.com "Just google, nothing fancy")


