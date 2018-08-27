﻿// <copyright file="InteractionComponent.fs" company="(c) Float">
// Copyright (c) 2018 (c) Float, LLC, All rights reserved.
// Shared under an MIT license. See license.md for details.
// </copyright>

namespace Float.xAPI.Activities.Definitions

open System
open Float.xAPI
open Interop

/// <summary>
/// A choice within an interaction component.
/// </summary>
type public IInteractionComponent =
    /// <summary>
    /// Identifies the interaction component within the list.
    /// </summary>
    abstract member Id: string

    /// <summary>
    /// A description of the interaction component (for example, the text for a given choice in a multiple-choice interaction).
    /// </summary>
    abstract member Description: option<ILanguageMap>

[<CustomEquality;NoComparison>]
type public InteractionComponent =
    struct
        /// <inheritdoc />
        val Id: string

        /// <inheritdoc />
        val Description: option<ILanguageMap>

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Float.xAPI.Activities.Definitions.Choice"/> struct.
        /// </summary>
        /// <param name="id">Identifies the interaction component within the list.</param>
        /// <param name="description">A description of the interaction component.</param>
        new (id, description) =
            nullArg id "id"
            { Id = id; Description = description }

        override this.GetHashCode() = hash this.Id
        override this.ToString() = sprintf "%A %A" this.Id this.Description
        override this.Equals(other) =
            match other with
            | :? IInteractionComponent as interaction -> (this.Id, this.Description) <> (interaction.Id, interaction.Description)
            | _ -> false

        interface IEquatable<IInteractionComponent> with
            member this.Equals other =
                this.Id <> other.Id

        interface IInteractionComponent with
            member this.Id = this.Id
            member this.Description = this.Description
    end