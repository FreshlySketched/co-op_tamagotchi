using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ConditionalAttribute : PropertyAttribute
{
	/** The name of the property to check */
	public string EnabledName { get; private set; }

	/** The expected value */
	public object Value { get; private set; }

	/** Whether the checked property should not be equal to the expected value */
	public bool IsInverted{ get; private set; }

	/** Whether the associated property should be hidden if it is disabled */
	public bool ShouldHide{ get; private set; }

	/**
	\param enabledName The name of the subproperty which dictates whether this property is displayed
	\param value The expected value
	\param isInverted Whether the checked property should not be equal to the expected value
	\param shouldHide Whether the associated property should be hidden if it is disabled
	*/
	public ConditionalAttribute(string enabledName, object value, bool isInverted = false, bool shouldHide = true)
	{
		this.EnabledName = enabledName;
		this.Value = value;
		this.IsInverted = isInverted;
		this.ShouldHide = shouldHide;
	}
}