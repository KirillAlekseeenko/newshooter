﻿#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

// UnityEngine.AudioSource
struct AudioSource_t1740077639;
// SoundManager
struct SoundManager_t2444342206;

#include "UnityEngine_UnityEngine_MonoBehaviour667441552.h"

#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SoundManager
struct  SoundManager_t2444342206  : public MonoBehaviour_t667441552
{
public:
	// UnityEngine.AudioSource SoundManager::musicSource
	AudioSource_t1740077639 * ___musicSource_2;
	// UnityEngine.AudioSource SoundManager::effectsSource
	AudioSource_t1740077639 * ___effectsSource_3;

public:
	inline static int32_t get_offset_of_musicSource_2() { return static_cast<int32_t>(offsetof(SoundManager_t2444342206, ___musicSource_2)); }
	inline AudioSource_t1740077639 * get_musicSource_2() const { return ___musicSource_2; }
	inline AudioSource_t1740077639 ** get_address_of_musicSource_2() { return &___musicSource_2; }
	inline void set_musicSource_2(AudioSource_t1740077639 * value)
	{
		___musicSource_2 = value;
		Il2CppCodeGenWriteBarrier(&___musicSource_2, value);
	}

	inline static int32_t get_offset_of_effectsSource_3() { return static_cast<int32_t>(offsetof(SoundManager_t2444342206, ___effectsSource_3)); }
	inline AudioSource_t1740077639 * get_effectsSource_3() const { return ___effectsSource_3; }
	inline AudioSource_t1740077639 ** get_address_of_effectsSource_3() { return &___effectsSource_3; }
	inline void set_effectsSource_3(AudioSource_t1740077639 * value)
	{
		___effectsSource_3 = value;
		Il2CppCodeGenWriteBarrier(&___effectsSource_3, value);
	}
};

struct SoundManager_t2444342206_StaticFields
{
public:
	// SoundManager SoundManager::instance
	SoundManager_t2444342206 * ___instance_4;

public:
	inline static int32_t get_offset_of_instance_4() { return static_cast<int32_t>(offsetof(SoundManager_t2444342206_StaticFields, ___instance_4)); }
	inline SoundManager_t2444342206 * get_instance_4() const { return ___instance_4; }
	inline SoundManager_t2444342206 ** get_address_of_instance_4() { return &___instance_4; }
	inline void set_instance_4(SoundManager_t2444342206 * value)
	{
		___instance_4 = value;
		Il2CppCodeGenWriteBarrier(&___instance_4, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif