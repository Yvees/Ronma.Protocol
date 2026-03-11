# Ronma.Protocol

## 概述

`Ronma.Protocol` 是 Ronma 系统的协议与抽象层。

它定义分布式 Ronma 服务之间共享的最小公共契约，包括：

- 基础枚举
- 输入输出接口
- 服务接口
- 跨服务传输结构
- LLM 请求与响应结构

这一层不包含具体运行时逻辑，不依赖 RabbitMQ、OpenAI 或任何具体服务实现。它的目标是让核心层、官方服务、第三方服务在同一组稳定协议上协作。

## 项目目标

- 为 Ronma 的分布式服务体系提供统一契约。
- 将协议定义与具体实现解耦，降低核心层与外部服务之间的耦合度。
- 为未来开源和第三方扩展提供稳定边界。
- 让不同实现可以在不共享内部代码的前提下完成互操作。

## 设计原则

### 1. 协议先于实现

核心服务、外围服务、桥接服务都先围绕协议协作，再在各自仓库中实现行为。

### 2. 契约保持最小化

这一层只保留跨边界必须共享的抽象，不承载具体业务策略、运行时状态机或基础设施细节。

### 3. 面向分布式通信

协议中的核心对象不是本地函数调用模型，而是面向服务总线的消息模型。`Packet`、`ServiceInfo`、`RequestId`、`TraceId`、`SessionId` 都服务于这一目标。

### 4. 面向可插拔服务

Ronma 将外围能力统一视为服务，也可以视为工具。协议层通过 `ServiceInfo` 与 `ServiceCommand` 描述能力边界，使第三方服务能够被 Insight 与 Core 统一发现和调用。

## 核心内容

### 枚举

- `BusChannel`
  - 定义输入、输出、内部三个通信通道。
- `AgentEventType`
  - 定义运行时看到的事件类型，如用户输入、服务结果、跟进任务等。
- `AgentActionType`
  - 定义 LLM 决策后的动作类型，如思考、服务调用、跟进、最终输出、错误。
- `LlmProvider`
  - 定义 LLM 提供商类型。
- `LlmContentPayloadType`
  - 定义多模态负载的媒体类型。

### 基础结构

- `Packet`
  - Ronma 的基础消息载体。
  - 一个 `Packet` 同时承载目标服务、命令、参数以及链路上下文。
- `ServiceInfo`
  - 服务描述对象，用于服务注册、服务发现和能力暴露。
- `ServiceCommand`
  - 服务命令的最小描述。
- `EndpointInfo`
  - 外部端点配置结构，用于描述总线或其他连接端点。

### LLM 结构

- `LlmEndpoint`
  - 描述模型端点与默认模型配置。
- `LlmContent`
  - 描述一次模型调用的输入。
- `LlmContentPayload`
  - 描述文本外的附加负载。
- `LlmResponse`
  - 保留模型响应的原始信息。
- `LlmResult`
  - 对上层更友好的执行结果结构。

### 接口

- 服务接口
  - `IService` 是所有服务的基础接口。
  - `ICoreService`、`IInsightService`、`IMemoryService`、`ILlmService` 等描述不同类型服务的能力边界。
- 输入输出接口
  - `IInput` / `IOutput` 以及文本、音频、视觉子接口定义输入输出通道的抽象类型。

## 工作原理

在 Ronma 中，服务之间不会共享内部对象图，而是通过协议层共享一套公共语言：

1. 服务使用 `ServiceInfo` 暴露自身能力。
2. 消息通过 `Packet` 在总线上传递。
3. `TraceId` 用于跨服务追踪一条执行链。
4. `SessionId` 用于维持会话上下文。
5. `RequestId` 用于请求与结果的配对。
6. Core 和外围服务通过共享的枚举和结构理解彼此的意图。

因此，`Ronma.Protocol` 的价值不在于“提供能力”，而在于“定义能力如何被描述和传递”。

## 与其他项目的边界

### 与 `Ronma.Common`

`Ronma.Protocol` 不负责总线实现、配置读取、LLM SDK 适配和编解码辅助。这些属于 `Ronma.Common`。

### 与 `Ronma.Core`

`Ronma.Protocol` 不负责 Agent 路由、Prompt 组装、会话状态、动作分发和运行时调度。这些属于 `Ronma.Core`。

### 与 `Ronma.Services`

`Ronma.Protocol` 不负责音频、IO、Bridge、管理界面等实际服务实现。它只为这些实现提供统一契约。

## 适用对象

- Ronma 核心层开发者
- Ronma 官方服务开发者
- 第三方服务实现者
- 需要基于 Ronma 协议构建适配层或桥接层的开发者

## 不负责的内容

- 不提供默认总线实现
- 不提供默认存储实现
- 不提供默认 Agent 实现
- 不提供具体服务逻辑
- 不定义系统部署方式

## 总结

`Ronma.Protocol` 是 Ronma 分布式体系的公共契约层。

它强调稳定、最小、清晰的协议边界，使核心系统与外部服务可以独立演进，同时保持互操作能力。这一层未来可以独立开放，作为 Ronma 生态的基础协议包被复用。
