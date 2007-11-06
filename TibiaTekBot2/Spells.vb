'    Copyright (C) 2007 TibiaTek Development Team
'
'    This file is part of TibiaTek Bot.
'
'    TibiaTek Bot is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    TibiaTek Bot is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with TibiaTek Bot. If not, see http://www.gnu.org/licenses/gpl.txt
'    or write to the Free Software Foundation, 59 Temple Place - Suite 330,
'    Boston, MA 02111-1307, USA.Imports System.Math

Imports System.xml

Public Module SpellsModule

    Public Structure SpellDefinition
        Dim Name As String
        Dim Words As String
        Dim ManaPoints As UShort
    End Structure

    Public Structure ConjureDefinition
        Dim Name As String
        Dim Words As String
        Dim ManaPoints As UShort
        Dim SoulPoints As Integer
    End Structure

    Public Class Spells

        Public Conjures As New List(Of ConjureDefinition)
        Public SupportiveSpells As New List(Of SpellDefinition)

        Public Sub New()
            LoadSpells()
        End Sub

        Public Sub LoadSpells()
            Dim Reader As New System.Xml.XmlTextReader(GetConfigurationDirectory() + "\Spells.xml")
            Dim Conjure As ConjureDefinition
            Dim Spell As SpellDefinition
            Dim Value As String
            SupportiveSpells.Clear()
            Conjures.Clear()
            Reader.WhitespaceHandling = WhitespaceHandling.None
            While Reader.Read()
                If Reader.NodeType = XmlNodeType.Element Then
                    Select Case Reader.Name
                        Case "Conjures"
                            While Reader.Read()
                                If Reader.NodeType = XmlNodeType.Element AndAlso Reader.Name = "Conjure" Then
                                    If Reader.HasAttributes Then
                                        Conjure.Name = Reader.GetAttribute("Name")
                                        Conjure.Words = Reader.GetAttribute("Words")
                                        Value = Reader.GetAttribute("Mana")
                                        If Value.Length > 0 AndAlso Value.Chars(0) = "H" Then Value = "&" + Value
                                        Conjure.ManaPoints = CUShort(Value)
                                        Value = Reader.GetAttribute("Soul")
                                        If Value.Length > 0 AndAlso Value.Chars(0) = "H" Then Value = "&" + Value
                                        Conjure.SoulPoints = CInt(Value)
                                        Conjures.Add(Conjure)
                                    End If
                                ElseIf Reader.NodeType = XmlNodeType.EndElement AndAlso Reader.Name = "Conjures" Then
                                    Exit While
                                End If
                            End While
                        Case "Supportives"
                            While Reader.Read()
                                If Reader.NodeType = XmlNodeType.Element AndAlso Reader.Name = "Spell" Then
                                    If Reader.HasAttributes Then
                                        Spell.Name = Reader.GetAttribute("Name")
                                        Spell.Words = Reader.GetAttribute("Words")
                                        Value = Reader.GetAttribute("Mana")
                                        If Value.Length > 0 AndAlso Value.Chars(0) = "H" Then Value = "&" + Value
                                        Spell.ManaPoints = CUShort(Value)
                                        SupportiveSpells.Add(Spell)
                                    End If
                                ElseIf Reader.NodeType = XmlNodeType.EndElement AndAlso Reader.Name = "Supportives" Then
                                    Exit While
                                End If
                            End While
                    End Select
                End If
            End While
        End Sub

        Public Function GetSpellWords(ByVal Name As String) As String
            For Each Spell As SpellDefinition In SupportiveSpells
                If String.Compare(Name, Spell.Name, True) = 0 Then
                    Return Spell.Words
                End If
            Next
            Return ""
        End Function

        Public Function GetSpellMana(ByVal Name As String) As UShort
            For Each Spell As SpellDefinition In SupportiveSpells
                If String.Compare(Name, Spell.Name, True) = 0 Then
                    Return Spell.ManaPoints
                End If
            Next
            Return 0
        End Function

    End Class

End Module
